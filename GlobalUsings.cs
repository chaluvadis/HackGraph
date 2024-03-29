global using System;
global using System.Text.Json;
global using Azure.Identity;
global using Microsoft.Graph;
global using Microsoft.Graph.Models;
global using Microsoft.Kiota.Abstractions;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Logging.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using HackGraph.Config;
global using HackGraph.Client;
global using HackGraph.Services;
global using HackGraph.Extensions;
global using HackGraph.Brokers.DateTimes;