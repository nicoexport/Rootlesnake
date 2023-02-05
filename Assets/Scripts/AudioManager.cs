using System;
using UnityEngine;

namespace DefaultNamespace {
    public class AudioManager : MonoBehaviour {

        public static AudioManager instance { get; private set; }
        
        void Awake() {
            instance = this;
        }

        public void PlayAudio(Audio audio) {
            switch (audio) {
                case Audio.RootCollide:
                   // FMODUnity.RuntimeManager.PlayOneShot("event:/Root_Colide");
                    break;
                case Audio.RootGrow:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Root_Grow");
                    break;
                case Audio.RootSplit:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Root_Split");
                    break;
                case Audio.NutrientCollect:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Nutrient_Collect");
                    break;
                case Audio.MenuSelect:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Select");
                    break;
                case Audio.MenuPressUp:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_PressUp");
                    break;
                case Audio.MenuPressDown:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_PressDown");
                    break;
                case Audio.MenuConfirm:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Confirm");
                    break;
                case Audio.MenuCancel:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_Cancel");;
                    break;
                case Audio.MenuBGM:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Menu_BGM");
                    break;
                case Audio.BGM:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/BGM");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(audio), audio, null);
            }
        }
    }
    
    public enum Audio{
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
        BGM
    }
}