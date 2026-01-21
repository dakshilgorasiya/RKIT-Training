using Microsoft.Extensions.Options;

namespace OptionPatternDemo.Settings
{
    public class DatabaseSettingsWatcher
    {
        private readonly IOptionsMonitor<DatabaseSettings> _optionsMonitor;

        public DatabaseSettingsWatcher(IOptionsMonitor<DatabaseSettings> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;

            _optionsMonitor.OnChange(settings =>
            {
                Console.WriteLine("Db setting changed");
            });
        }
    }
}
