using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    public Animator Border, Text, Note;

    [SerializeField]
    private NoteType noteType;

    private bool Clicked = false;

    private void Start()
    {
        switch (noteType)
        {
            case NoteType.Note_1:
                SetIDParams(0);
                break;

            case NoteType.Note_2:
                SetIDParams(1);
                break;

            case NoteType.Note_3:
                SetIDParams(2);
                break;

            case NoteType.Note_4:
                SetIDParams(3);
                break;

            case NoteType.Note_5:
                SetIDParams(4);
                break;

            default:
                Debug.Log("something went wrong..");
                break;
        }
    }


    public void ClickButton()
    {
        Clicked = true;
        SetParams(true);
    }

    private void SetParams(bool value)
    {
        Border.SetBool("Clicked", value);
        Text.SetBool("Clicked", value);
        Note.SetBool("Clicked", value);
    }

    private void SetIDParams(int id)
    {
        Note.SetInteger("Note ID", id);
    }



    private void Update()
    {
        if (Clicked)
        {
            if (!AnimatorIsPlaying(Border, 0, "Border Anim Idle"))
            {
                Clicked = false;
                SetParams(false);

                print("Change scene now!");
                // Change Scene here
            }
            else
                print("Delay!");
        }
    }

    private bool AnimatorIsPlaying(Animator anim, int layer, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsName(stateName) && anim.GetNextAnimatorStateInfo(layer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}

public enum NoteType
{
    Note_1,
    Note_2,
    Note_3,
    Note_4,
    Note_5
}