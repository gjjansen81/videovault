//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"

namespace VideoVault.WebApi
{
    using System = global::System;
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface ICustomerClient
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CustomerDto> CreateAsync(UpsertCustomerCommand command, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CustomerDto> UpdateAsync(int id, UpsertCustomerCommand command, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FileResponse> DeleteAsync(int id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<CustomerDto>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CustomerDto> GetByIdAsync(int id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IIdentityClient
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<OutputResultOfString> CreateAsync(CreateIdentityCommand command, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<OutputResultOfAuthenticationDto> AuthenticateAsync(string userName = null, string password = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IKeyGenClient
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FileResponse> GenerateKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IUserClient
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FileResponse> UpdateAsync(int id, object command, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FileResponse> DeleteAsync(int id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FileResponse> GetAsync(int? id = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IWeatherForecastClient
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<WeatherForecast>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class CustomerDto 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("createdOn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CreatedOn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastChangedOn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastChangedOn { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static CustomerDto FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerDto>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class UpsertCustomerCommand 
    {
        [Newtonsoft.Json.JsonProperty("customer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CustomerDto Customer { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static UpsertCustomerCommand FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UpsertCustomerCommand>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class OutputResultOfString : Result
    {
        [Newtonsoft.Json.JsonProperty("output", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Output { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static OutputResultOfString FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OutputResultOfString>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Result 
    {
        [Newtonsoft.Json.JsonProperty("succeeded", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Succeeded { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static Result FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class CreateIdentityCommand 
    {
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static CreateIdentityCommand FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CreateIdentityCommand>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class OutputResultOfAuthenticationDto : Result
    {
        [Newtonsoft.Json.JsonProperty("output", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AuthenticationDto Output { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static OutputResultOfAuthenticationDto FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OutputResultOfAuthenticationDto>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthenticationDto 
    {
        [Newtonsoft.Json.JsonProperty("token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Token { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expirationDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ExpirationDate { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static AuthenticationDto FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticationDto>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class WeatherForecast 
    {
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset Date { get; set; }
    
        [Newtonsoft.Json.JsonProperty("temperatureC", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TemperatureC { get; set; }
    
        [Newtonsoft.Json.JsonProperty("temperatureF", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TemperatureF { get; set; }
    
        [Newtonsoft.Json.JsonProperty("summary", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Summary { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    
        public static WeatherForecast FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherForecast>(data);
        }
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class FileResponse : System.IDisposable
    {
        private System.IDisposable _client;
        private System.IDisposable _response;

        public int StatusCode { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public System.IO.Stream Stream { get; private set; }

        public bool IsPartial
        {
            get { return StatusCode == 206; }
        }

        public FileResponse(int statusCode, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.IO.Stream stream, System.IDisposable client, System.IDisposable response)
        {
            StatusCode = statusCode; 
            Headers = headers; 
            Stream = stream; 
            _client = client; 
            _response = response;
        }

        public void Dispose() 
        {
            Stream.Dispose();
            if (_response != null)
                _response.Dispose();
            if (_client != null)
                _client.Dispose();
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.9.4.0 (NJsonSchema v10.3.1.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108