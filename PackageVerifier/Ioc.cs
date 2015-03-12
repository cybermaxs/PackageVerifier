using StructureMap;

namespace PackageVerifier
{
    public static class Ioc
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
