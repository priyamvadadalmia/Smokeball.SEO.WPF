using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmokeBall.SEO.Service
{
    public interface IHttpWebClient
    {
        string Get(string url);
    }
}
