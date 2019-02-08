using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace MKT.Logica.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
        public LoginResponse()
        {
            this.Token = string.Empty;
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized};
        }

    }
}
