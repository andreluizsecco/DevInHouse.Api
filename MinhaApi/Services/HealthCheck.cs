using MinhaApi.Interfaces;

namespace MinhaApi.Services
{
    public class HealthCheck : IHealthCheck
    {
        public bool EstaSaudavel()
        {
            //Simulando um health check normal
            return false;
        }
    }
}