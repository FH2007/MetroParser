namespace MetroParserApi.Services
{
    public class ScheduleBackgroundService : IHostedService
    {
        //private readonly ILoggerFactory _loggerFactory;
        //private readonly ILoggerProvider _logger;
        //public ScheduleBackgroundService(ILoggerFactory loggerFactory)
        //{
        //    //this._loggerFactory = loggerFactory;
        //    //this._logger = loggerFactory.CreateLogger<Logger>();
        //}
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Не блокируем поток выполнения: StartAsync должен запустить выполнение фоновой задачи и завершить работу
            UpdateScheduleAsync(cancellationToken);
            return Task.CompletedTask;
        }

        

        private async Task UpdateScheduleAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    //_logger.LogInformation("Update", "Start");
                    await ScheduleParser.UpdateSchedule();
                    //_logger.LogInformation("Update", "End");
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex.Message);
                    // обработка ошибки однократного неуспешного выполнения фоновой задачи
                }

                await Task.Delay(10000, stoppingToken);
            }
            
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
