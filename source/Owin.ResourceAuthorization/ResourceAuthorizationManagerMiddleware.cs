﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thinktecture.IdentityModel.Owin.ResourceAuthorization
{
    public class ResourceAuthorizationManagerMiddleware
    {
        public const string Key = "idm:resourceAuthorizationManager";

        private readonly Func<IDictionary<string, object>, Task> _next;
        private ResourceAuthorizationMiddlewareOptions _options;

        public ResourceAuthorizationManagerMiddleware(Func<IDictionary<string, object>, Task> next, ResourceAuthorizationMiddlewareOptions options)
        {
            _options = options;
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            env[Key] = _options.Manager;
            await _next(env);
        }
    }
}