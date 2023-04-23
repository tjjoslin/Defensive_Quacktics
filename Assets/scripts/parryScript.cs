using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parryScript : MonoBehaviour
{

    const float timeToCountAsHeldDown = 0.3f;
    float pressTimer = 0;
    IEnumerator parryChecker()
    {
        while (true)
        {
            //Check when the Space key is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Continue to check if it is still heldown and keep counting the how long
                while (Input.GetKey(KeyCode.Space))
                {
                    //Start incrementing timer
                    pressTimer += Time.deltaTime;

                    //Check if this counts as being "Held Down"
                    if (pressTimer > timeToCountAsHeldDown)
                    {
                        //It a "key held down", call the OnKeyHeldDown function and wait for it to return
                        yield return OnKeyHeldDown();
                        //No need to continue checking for Input.GetKey(KeyCode.D). Break out of this whule loop
                        break;
                    }

                    //Wait for a frame
                    yield return null;
                }
            }


            //Check if "D" key is released 
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //Check if we have not not reached the timer then it is only a key press
                if (pressTimer < timeToCountAsHeldDown)
                {
                    //It just a key press, call the OnKeyPressedOnly function and wait for it to return
                    yield return OnKeyPressedOnly();
                }

                //Reset timer to 0 for the next key press
                pressTimer = 0f;
            }

            //Wait for a frame
            yield return null;
        }
    }

    IEnumerator OnKeyPressedOnly()
    {
        Debug.Log("Space key was only Pressed");


        yield return null;
    }


    IEnumerator OnKeyHeldDown()
    {
        Debug.LogWarning("Space key is Held Down");

        //Don't move for 0.5 seconds 
        yield return new WaitForSeconds(0.5f);

            //Wait for a frame
            yield return null;
        
    }
}
