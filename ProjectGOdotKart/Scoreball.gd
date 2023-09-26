extends RigidBody

#onready var target = $Player
onready var daTarget = get_parent().get_node("Scoreball")
onready var player = get_parent().get_node("GridContainer/ViewportContainer/Viewport/Player")
#onready var player2 = get_parent().get_node("GridContainer/ViewportContainer/Viewport/Player2")

#bool touche

# func look_follow(state, current_transform, target_position):
#   var up_dir = Vector3(0, 1, 0)
#   var cur_dir = current_transform.basis.xform(Vector3(0, 0, 1)) 
#   var target_dir = (target_position - current_transform.origin).normalized()
#   var rotation_angle = acos(cur_dir.x) - acos(target_dir.x)
#
#   state.set_angular_velocity(up_dir * (rotation_angle / state.get_step()))
#
#func _integrate_forces(state):
#    var target_position = target.get_global_transform().origin
#    look_follow(state, get_global_transform(), target_position)
#    add_central_force(Vector3(0,0,5))

func _physics_process(delta):
#	if 
		apply_central_impulse(Vector3.FORWARD* delta)

func safe_look_at(spatial: Spatial, target: Vector3) -> void:
	var origin : Vector3 = spatial.global_transform.origin
	var v_z :=(origin - target).normalized()
	
	if origin == target:
		return
	
	var up := Vector3.ZERO
	for entry in [Vector3.RIGHT, Vector3.UP, Vector3.BACK]:
		var v_x : Vector3 = entry.cross(v_z).normalized()
		if v_x.length() != 0:
			up = entry
			
		if up != Vector3.ZERO:
			spatial.look_at(target,up)


#func _on_Player_body_entered(body):
#	safe_look_at(body, daTarget.global_transform.origin)
#	if body is RigidBody:
#		print("boo.")
