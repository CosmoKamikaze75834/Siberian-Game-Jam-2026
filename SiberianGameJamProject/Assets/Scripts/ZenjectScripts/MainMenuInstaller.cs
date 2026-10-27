using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AudioVolume>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AudioPlayer>().FromComponentInHierarchy().AsSingle();
    }
}