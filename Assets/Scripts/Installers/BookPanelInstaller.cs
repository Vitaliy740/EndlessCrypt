using UnityEngine;
using Zenject;

public class BookPanelInstaller : MonoInstaller
{
    public BookReader Reader;
    public override void InstallBindings()
    {
        Container.BindInstance<BookReader>(Reader).AsSingle();
    }
}