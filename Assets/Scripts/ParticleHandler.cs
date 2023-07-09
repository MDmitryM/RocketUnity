using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _winningParticle;
    [SerializeField] private ParticleSystem _crashingParticle;
    [SerializeField] private ParticleSystem _leftRotationParticle;
    [SerializeField] private ParticleSystem _rightRotationParticle;
    [SerializeField] private ParticleSystem _middleParticle;

    //////////////////////////////////////////
    ///PLAY PARTICLES FUNCS
    /// 
    public void WinningParticle() 
    {
        _winningParticle.Play();
    }

    public void CrashingParticle()
    {
        _crashingParticle.Play();
    }

    public void RightRotationParticleStart() 
    {
        _leftRotationParticle.Play();
    }
    public void LeftRotationParticleStart() 
    {
        _rightRotationParticle.Play();
    }

    public void MiddleParticleStart()
    {
        _middleParticle.Play();
    }
    //////////////////////////////////////////
    ///STOP ROTATION PARTICLES FUNCS
    /// 
    public void RightRotationParticleStop()
    {
        _leftRotationParticle.Stop();
    }
    public void LeftRotationParticleStop()
    {
        _rightRotationParticle.Stop();
    }

    public void MiddleParticleStop()
    {
        _middleParticle.Stop();
    }
    //////////////////////////////////////////
    ///IS PARTICLES PLAYING FUNCS
    /// 
    public bool IsMiddleParticlePlaying() 
    {
        return _middleParticle.isPlaying;
    }

    public bool IsRightParticlePlaying()
    {
        return _leftRotationParticle.isPlaying;
    }

    public bool IsLeftParticlePlaying()
    {
        return _rightRotationParticle.isPlaying;
    }
}
