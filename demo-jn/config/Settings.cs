using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.DotNet.Interactive;
using InteractiveKernel = Microsoft.DotNet.Interactive.Kernel;

/// <summary>
/// Settings class
/// </summary>
public static class Settings
{
    private const string DefaultConfigFile = "config/settings.json";
    private const string ModelKey = "model";
    private const string EndpointKey = "endpoint";
    private const string SecretKey = "apikey";
    private const bool StoreConfigOnFile = true;

    /// <summary>
    /// Load configuration from file
    /// </summary>
    /// <param name="configFile"></param>
    /// <returns>Configuration not found</returns>
    /// <exception cref="Exception">Configuration not found</exception>
    public static (string model, string azureEndpoint, string apiKey)
        LoadFromFile(string configFile = DefaultConfigFile)
    {
        if (!File.Exists(configFile))
        {
            Console.WriteLine("Configuration not found: " + configFile);
            throw new Exception("Configuration not found: " + configFile);
        }

        try
        {
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(configFile));
            string model = config[ModelKey];
            string azureEndpoint = config[EndpointKey];
            string apiKey = config[SecretKey];

            return (model, azureEndpoint, apiKey);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong: " + e.Message);
            return ("", "", "");
        }
    }
}