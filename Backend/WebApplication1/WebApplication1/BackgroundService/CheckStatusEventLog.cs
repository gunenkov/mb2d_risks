using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.BackgroundService
{
    public class CheckStatusEventLog : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly int _interval = 10;

        public CheckStatusEventLog(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        //Основной процесс проверки
        private async Task DoWorkAsync()
        {
            var currentDate = DateTime.Now.ToLocalTime();
            //получаем контекст
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

            //получаем активные события (дата начала меньше текущего и статус активный)
            var activeEvents = context.EventsLogs.Where(x => x.Start < currentDate)
                .Where(x => x.Status == EventLogStatus.Active).ToList();
            //для каждого события
            foreach (var myevent in activeEvents)
            {
                //получаем продолжительность
                var duration = context.Events.FirstOrDefault(x => x.Id == myevent.Id).DurationInSeconds;
                //если конец меньше текущей даты
                if (myevent.Start.AddSeconds(duration) < currentDate)
                {
                    //и произошёл внешний фактор
                    if (myevent.IsExternalFactor)
                    {
                        //то статус завершено неудачно
                        myevent.Status = EventLogStatus.Failed;
                    }
                }
                //иначе
                else
                {
                    //статус завершено успешно
                    myevent.Status = EventLogStatus.Success;
                }

                await context.SaveChangesAsync();
            }
        }

        //запуск таймера
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await DoWorkAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                await Task.Delay(TimeSpan.FromSeconds(_interval), stoppingToken);
            }
        }
    }
}
