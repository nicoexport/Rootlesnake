using System;
using FMOD.Studio;
using UnityEngine;

namespace Rootlesnake {
    sealed class AudioManager : MonoBehaviour {

        public static AudioManager instance { get; private set; }

        void Awake() {
            instance = this;
        }

        static EventInstance music;

        public void PlayAudio(EffectCue audio) {
            switch (audio) {
                case EffectCue.RootCollide:
                    // FMODUnity.RuntimeManager.PlayOneShot("event:/Root_Colide");
                    break;
                case EffectCue.RootGrow:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Root_Grow");
                    break;
                case EffectCue.RootSplit:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Root_Split");
                    break;
                case EffectCue.NutrientCollect:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Nutrient_Collect");
                    break;
                case EffectCue.MenuSelect:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Select");
                    break;
                case EffectCue.MenuPressUp:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_PressUp");
                    break;
                case EffectCue.MenuPressDown:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_PressDown");
                    break;
                case EffectCue.MenuConfirm:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Confirm");
                    break;
                case EffectCue.MenuCancel:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Cancel");
                    break;
                case EffectCue.MenuBGM:
                    music.stop(STOP_MODE.ALLOWFADEOUT);
                    music = FMODUnity.RuntimeManager.CreateInstance("event:/Menu_BGM");
                    music.start();
                    break;
                case EffectCue.BGM:
                    music.stop(STOP_MODE.ALLOWFADEOUT);
                    music = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
                    music.start();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(audio), audio, null);
            }
        }
    }

    public enum EffectCue {
        RootCollide,
        RootGrow,
        RootSplit,
        NutrientCollect,
        MenuSelect,
        MenuPressUp,
        MenuPressDown,
        MenuConfirm,
        MenuCancel,
        MenuBGM,
        BGM,
        PlantGrow,
    }
}