﻿using _17_ProjectsFinder.Send;
using Newtonsoft.Json;
using ServerProjectsFinder.Model;
using ServerProjectsFinder.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerProjectsFinder.Controller
{
    public class AuthorizationController : ControllerBase
    {
        private AuthorizationModel Model = new AuthorizationModel();
        private AuthorizationView View = new AuthorizationView();
        private bool Result;
        public override void Work(string json)
        {
            var obj = JsonConvert.DeserializeObject<AuthorizationRequest>(json);
            Result = Model.Authorization(obj.Login, obj.Password);
            View.SentResultOFAuthorizationToClient(Result);
        }
    }
}
