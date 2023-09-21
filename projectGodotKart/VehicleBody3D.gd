extends VehicleBody3D

var max_rpm = 500
var max_torque = 200

func _physics_process(delta):
	steering = lerp( steering, Input.get_axis("Right","Left") * 0.4, 5 * delta)
	engine_force = Input.get_axis("Backward","Forward") * 100
	
#	var acceleration = Input.get_axis("Backward","Forward") * 100
#	var rpm = $B_L_WHeel.get_rpm()
#	$B_L_WHeel.engine_force = acceleration * max_torque * (1 - rpm / max_rpm)
#	rpm = $B_R_WHeel.get_rpm()
#	$B_R_WHeel.engine_force = acceleration * max_torque * (1 - rpm / max_rpm)
