using UnityEngine;
using Zenject;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "MixerInstaller", menuName = "Installers/MixerInstaller")]
public class MixerInstaller : ScriptableObjectInstaller<MixerInstaller>
{
    public AudioMixer Mixer;
    public override void InstallBindings()
    {
        Container.BindInstance<AudioMixer>(Mixer).AsSingle();
    }
}