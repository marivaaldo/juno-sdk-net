using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk
{
    public enum EnvironmentUrl
    {
        Authorization,

        Resources
    }

    public enum EnvironmentType
    {
        Sandbox,
        Production
    }

    public interface IEnvironment
    {
        EnvironmentType Type { get; }
        string AuthorizationUrl { get; }
        string ResourcesUrl { get; }
        string GetUrl(string resource, EnvironmentUrl baseUrl = EnvironmentUrl.Resources);
    }

    public abstract class AbstractEnvironment : IEnvironment
    {
        public abstract EnvironmentType Type { get; }

        public abstract string AuthorizationUrl { get; }

        public abstract string ResourcesUrl { get; }

        public string GetUrl(string resource, EnvironmentUrl baseUrl = EnvironmentUrl.Resources)
        {
            var url = baseUrl switch
            {
                EnvironmentUrl.Authorization => AuthorizationUrl,
                EnvironmentUrl.Resources => ResourcesUrl,
                _ => throw new InvalidOperationException()
            };

            if (resource.StartsWith("/"))
            {
                resource = resource[1..];
            }

            return $"{url}{resource}";
        }
    }

    public class SandboxEnvironment : AbstractEnvironment
    {
        public override EnvironmentType Type => EnvironmentType.Sandbox;
        public override string AuthorizationUrl => "https://sandbox.boletobancario.com/authorization-server/";
        public override string ResourcesUrl => "https://sandbox.boletobancario.com/api-integration/";

        private SandboxEnvironment() { }

        public static readonly IEnvironment Instance = new SandboxEnvironment();
    }

    public class ProductionEnvironment : AbstractEnvironment
    {
        public override EnvironmentType Type => EnvironmentType.Production;
        public override string AuthorizationUrl => "https://api.juno.com.br/authorization-server/";
        public override string ResourcesUrl => "https://api.juno.com.br/";

        private ProductionEnvironment() { }

        public static readonly IEnvironment Instance = new ProductionEnvironment();
    }
}
