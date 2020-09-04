using Newtonsoft.Json;
using Carrington_Service.Helpers;
using Carrington_Service.Infrastructure;
using Carrington_Service.Models;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;

namespace Carrington_Service.Agents
{
    public class AgentApi : IAgentApi
    {
        public ILogger Logger;
        private readonly IConfigHelper ConfigHelper;
     

        public AgentApi(IConfigHelper configHelper, ILogger logger)
        {
            ConfigHelper = configHelper;
            Logger = logger;
           
          
        }

    }
}

