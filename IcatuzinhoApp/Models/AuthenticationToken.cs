using System;
using PropertyChanged;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class AuthenticationToken : EntityBase
    { 
        [JsonProperty(PropertyName="access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName="token_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenType TokenType { get; set; }

        [JsonProperty(PropertyName="expires_in")]
        public TimeSpan ExpiresIn { get; set; }
    }
}

