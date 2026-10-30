using UnityEngine.InputSystem;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().AsSingle();

        Container.Bind<InputMove>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesTo<InputSystemPlayer>().FromComponentInHierarchy().AsSingle();
    }
}