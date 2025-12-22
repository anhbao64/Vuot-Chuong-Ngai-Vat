using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;   // nhạc nền
    public AudioSource sfxSource;     // hiệu ứng

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    [Header("Sound Effects")]
    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip powerupSound;
    public AudioClip buttonTapSound;
    public AudioClip hurtSound;
    public AudioClip explosionSound;

    private void Awake()
    {
        // 🔥 đảm bảo AudioManager là ROOT
        transform.SetParent(null);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    // ===== MUSIC =====
    public void PlayBackgroundMusic()
    {
        if (musicSource == null || backgroundMusic == null) return;

        if (!musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource != null)
            musicSource.Stop();
    }

    // ===== SFX =====
    public void PlayJump() { PlaySFX(jumpSound); }
    public void PlayCoin() { PlaySFX(coinSound); }
    public void PlayPowerUp() { PlaySFX(powerupSound); }
    public void PlayHurt() { PlaySFX(hurtSound); }
    public void PlayExplosion() { PlaySFX(explosionSound); }
    public void PlayButtonClick() { PlaySFX(buttonTapSound); }

    private void PlaySFX(AudioClip clip)
    {
        if (sfxSource == null || clip == null) return;
        sfxSource.PlayOneShot(clip);
    }
}
