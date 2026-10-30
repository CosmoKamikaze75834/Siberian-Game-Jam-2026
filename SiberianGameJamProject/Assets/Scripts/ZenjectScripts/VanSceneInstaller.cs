using Zenject;

public class VanSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().AsSingle();

        Container.Bind<InputMove>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputInteract>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InputPointer>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SceneLoader>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesTo<InputSystemPlayer>().FromComponentInHierarchy().AsSingle();
    }
}