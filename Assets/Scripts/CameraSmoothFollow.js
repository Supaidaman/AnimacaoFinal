var target : GameObject;
var zposition : float;
var yposition : float;

function Update()
{
    transform.position.y = target.transform.position.y;
    transform.position.x = target.transform.position.x;
    transform.position.z = zposition;
    transform.position.y = yposition;
} 