using SmokeBall.SEO.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmokeBall.SEO.Business
{
    public interface ISEResult
    {
        string Search(SearchRequest searchRequest);
    }
}
