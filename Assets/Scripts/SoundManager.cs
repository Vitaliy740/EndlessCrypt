using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    [HideInInspector]
    [Inject]
    public AudioMixer Mixer;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource MusicSource;
    public AudioClip BackGroundMusic;
    public AudioClip DeathSound;
    public AudioClip TaskCompleteSound;
    public float RandomScarySoundTime;
    public float RandomSoundTimeRange = 5f;
    public List<AudioClip> RandomScarySounds;
    public List<AudioClip> RandomBookSounds;
    public static SoundManager Instance;
    public float CurrentRandomSoundTreshold = 60f;
    [SerializeField]
    private bool _isInWater;
    public List<AudioClip> RandomStepSound;
    public List<AudioClip> RandomWaterStepSound;
    private float _currentTimeFromLastSound=0f;
    public List<AudioClip> RandomPickSound;

    public List<AudioClip> PutSounds = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        ResetMusic();
        if (Instance == null) 
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(this.gameObject);
        }
        CurrentRandomSoundTreshold += Random.Range(-RandomSoundTimeRange, RandomSoundTimeRange);
    }
    public AudioClip GetRandomStepSound() 
    {
        if (_isInWater)
        {
            return RandomWaterStepSound[Random.Range(0, RandomWaterStepSound.Count)];
        } 
        return RandomStepSound[Random.Range(0, RandomStepSound.Count)];
    }
    public void SetInWater(bool v) 
    {
        _isInWater = v;
    }
    public void ResetMusic()
    {
        MusicSource.clip = BackGroundMusic;
        MusicSource.Play();
    }
    public void PlayRandomBookSound() 
    {
        SFXSource.PlayOneShot(RandomBookSounds[Random.Range(0, RandomBookSounds.Count )]);
    }
    public void PlaySound(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip music) 
    {
        MusicSource.clip = music;
        MusicSource.Play();
    }
    public void PlayRandomPickUpSound() 
    {
        PlaySound(RandomPickSound[Random.Range(0, RandomPickSound.Count)]);
    }
    // Update is called once per frame
    public void PlayRandomPutSound() 
    {
        PlaySound(PutSounds[Random.Range(0, PutSounds.Count)]);
    }
    void Update()
    {
        _currentTimeFromLastSound += Time.deltaTime;
        if (_currentTimeFromLastSound > CurrentRandomSoundTreshold) 
        {
            _currentTimeFromLastSound = 0;
            SFXSource.PlayOneShot(RandomScarySounds[Random.Range(0,RandomScarySounds.Count)]);
            CurrentRandomSoundTreshold+= Random.Range(-RandomSoundTimeRange, RandomSoundTimeRange);
        }
    }
}
