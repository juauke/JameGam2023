using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceLoop;
    
	[SerializeField] private AudioClip[] jumpSounds;
	[SerializeField] private AudioClip edgeClimbSound;
	[SerializeField] private AudioClip[] wallJumpSounds;
	[SerializeField] private AudioClip[] attackSounds;
    [SerializeField] private AudioClip[] leftStepSounds;
    [SerializeField] private AudioClip[] rightStepSounds;
    [SerializeField] private AudioClip armorDropSound;
    [SerializeField] private AudioClip armorSoftDropSound;
    [SerializeField] private AudioClip[] armorJumpSounds;
    [SerializeField] private AudioClip[] swordSlashSounds;
    [SerializeField] private AudioClip[] swordHitSounds;
    [SerializeField] private AudioClip burningSound;
    [SerializeField] private AudioClip dropOnLiquidSound;
    [SerializeField] private AudioClip fartSound;
    [SerializeField] private AudioClip[] damageSound;
    [SerializeField] private AudioClip[] deathSound;
    
    
    
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = 1f;
    }
    
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
    }
    
    public void PlayDamageSound()
    {
        audioSource.PlayOneShot(damageSound[Random.Range(0, damageSound.Length)]);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound[Random.Range(0, deathSound.Length)]);
    }

    public void PlayFartSound()
    {
        audioSource.PlayOneShot(fartSound);
    }
    
    public void PlayDropOnLiquidSound()
    {
        audioSource.PlayOneShot(dropOnLiquidSound);
    }
    
    public void PlaySideGripSound()
    {
        if (audioSourceLoop.isPlaying) return;
        audioSourceLoop.Play();
    }
    public void StopSideGripSound()
    {
        if (!audioSourceLoop.isPlaying) return;
        StartCoroutine(StartFade(audioSourceLoop, 0.2f,  0f));
    }
    public void PlaySoftDropSound()
    {
        audioSource.PlayOneShot(armorSoftDropSound);
    }   
    
    public void PlayBurningSound()
    {
        audioSource.PlayOneShot(burningSound);
    }

    public void PlayLedgeClimb()
    {
        audioSource.PlayOneShot(edgeClimbSound);
    }
    
    public void PlayDropSound()
    {
        audioSource.PlayOneShot(armorDropSound);
    }
    
    public void PlayArmorJumpSound()
    {
        audioSource.PlayOneShot(armorJumpSounds[Random.Range(0, armorJumpSounds.Length)]);
    }
    
    public void PlaySwordSlashSound()
    {
        audioSource.PlayOneShot(swordSlashSounds[Random.Range(0, swordSlashSounds.Length)]);
    }
    
    public void PlaySwordHitSound()
    {
        audioSource.PlayOneShot(swordHitSounds[Random.Range(0, swordHitSounds.Length)]);
    }

	public void PlayWallJumpSound()
    {
        audioSource.PlayOneShot(wallJumpSounds[Random.Range(0, wallJumpSounds.Length)]);
    }
	public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);
    }
    
    public void PlayStepSound(string foot)
    {
        switch (foot)
        {
            case "LEFT":
                audioSource.PlayOneShot(leftStepSounds[Random.Range(0, leftStepSounds.Length)]);
                break;
            case "RIGHT":
                audioSource.PlayOneShot(rightStepSounds[Random.Range(0, rightStepSounds.Length)]);
                break;
        }
    }
}

