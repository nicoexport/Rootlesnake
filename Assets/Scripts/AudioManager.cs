using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace {
    public class AudioManager : MonoBehaviour {
        [SerializeField] private UnityEvent onRootCollide;
        [SerializeField] private UnityEvent onRootGrow;
        [SerializeField] private UnityEvent onRootSplit;
        [SerializeField] private UnityEvent onNutrientCollect;
        [SerializeField] private UnityEvent onMenuSelect;
        [SerializeField] private UnityEvent onMenuPressUp;
        [SerializeField] private UnityEvent onMenuPressDown;
        [SerializeField] private UnityEvent onMenuConfirm;
        [SerializeField] private UnityEvent onMenuCancel;
        [SerializeField] private UnityEvent onMenuBGM;
        [SerializeField] private UnityEvent onBGM;
        
        public static AudioManager instance { get; private set; }
        
        void Awake() {
            instance = this;
        }
        
        public void PlayAudio(Audio audio) {
            switch (audio) {
                case Audio.RootCollide:
                    onRootCollide.Invoke();
                    break;
                case Audio.RootGrow:
                    onRootGrow.Invoke();
                    break;
                case Audio.RootSplit:
                    onRootSplit.Invoke();
                    break;
                case Audio.NutrientCollect:
                    onNutrientCollect.Invoke();
                    break;
                case Audio.MenuSelect:
                    onMenuSelect.Invoke();
                    break;
                case Audio.MenuPressUp:
                    onMenuPressUp.Invoke();
                    break;
                case Audio.MenuPressDown:
                    onMenuPressDown.Invoke();
                    break;
                case Audio.MenuConfirm:
                    onMenuConfirm.Invoke();
                    break;
                case Audio.MenuCancel:
                    onMenuCancel.Invoke();
                    break;
                case Audio.MenuBGM:
                    onMenuBGM.Invoke();
                    break;
                case Audio.BGM:
                    onBGM.Invoke();
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