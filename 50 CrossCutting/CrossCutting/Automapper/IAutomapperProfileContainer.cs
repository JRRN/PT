using AutoMapper;

namespace CrossCutting.Automapper
{
    public interface IAutomapperProfileContainer
    {
        Profile GetProfile();
    }
}
