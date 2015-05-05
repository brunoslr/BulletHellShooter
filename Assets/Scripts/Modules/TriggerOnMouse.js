#pragma strict

public var mouseDownSignals : SignalSender;
public var mouseUpSignals : SignalSender;

private var clicked = false;

function Update () {
	if(clicked == false)
	{
		if (Input.GetMouseButtonDown(0))
		{
			mouseDownSignals.SendSignals (this);
			Debug.Log("Clicked");
			clicked = true;
		}
	}
	if(clicked == true)
	{
		if (Input.GetMouseButtonUp(0))
		{
			mouseUpSignals.SendSignals (this);
			clicked = false;
			Debug.Log("Not Clicked");
		}
	}
}
