namespace ServiceLocator
{
    public interface IServiceLocator<T>
    {
        TP Register<TP>(TP newService) where TP : T;

        void Remove<TP>(TP service) where TP : T;

        TP GetService<TP>() where TP : T;
    }
}