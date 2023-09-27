extends Spatial

onready var ball = $Ball
onready var car_mesh = $Kart
onready var ground_ray = $Kart/RayCast


export var player_ip = 1

var sphere_offset = Vector3(0,-0.1,0)
var acceleration = 50
var steering = 21.0
var turn_speed = 5
var turn_stop_limit = 0.75

var speed_input = 0
var rotate_input = 0

var touche : Array
var closest_touche

export var sped = 100
var player_position
onready var target = get_parent().get_parent().get_parent().get_parent().get_parent().get_node("Scoreball")
onready var player = get_parent().get_parent().get_parent().get_node("ViewportContainer/Viewport/Player")
#onready var player2 = get_parent().get_parent().get_parent().get_node("ViewportContainer/Viewport/Player2")

func _ready():
	ground_ray.add_exception(ball)
	
func _physics_process(_delta):
	# Keep the car mesh aligned with the sphere
	car_mesh.transform.origin = ball.transform.origin + sphere_offset

	# Accelerate based on car's forward direction
	ball.add_central_force(-car_mesh.global_transform.basis.z * speed_input)

	
	#player_position = player.player_position
	#target = (player_position - Position3D)
	

func _process(delta):
	# Can't steer/accelerate when in the air
	if not ground_ray.is_colliding():
		return
	# Get accelerate/brake input
	speed_input = 0
	speed_input += Input.get_action_strength("accelerate_%s" % [player_ip])
	speed_input -= Input.get_action_strength("brake_%s" % [player_ip])
	speed_input *= acceleration
	# Get steering input
	rotate_input = 0
	rotate_input += Input.get_action_strength("steer_left_%s" % [player_ip])
	rotate_input -= Input.get_action_strength("steer_right_%s" % [player_ip])
	rotate_input *= deg2rad(steering)

# rotate car mesh
	if ball.linear_velocity.length() > turn_stop_limit:
		var new_basis = car_mesh.global_transform.basis.rotated(car_mesh.global_transform.basis.y, rotate_input)
		car_mesh.global_transform.basis = car_mesh.global_transform.basis.slerp(new_basis, turn_speed * delta)
		car_mesh.global_transform = car_mesh.global_transform.orthonormalized()

	var n = ground_ray.get_collision_normal()
	var xform = align_with_y(car_mesh.global_transform, n.normalized())
	car_mesh.global_transform = car_mesh.global_transform.interpolate_with(xform, 10 * delta)

func align_with_y(xform, new_y):
	xform.basis.y = new_y
	xform.basis.x = -xform.basis.z.cross(new_y)
	xform.basis = xform.basis.orthonormalized()
	return xform

#to rotate the wheels
#onready var F_RWheel = get_parent().get_node("Player/Kart/F_R_Wheel")
#onready var F_LWheel = get_parent().get_node("Player/Kart/F_LWheel")
#F_RWheel.rotation.y = rotate_input
#F_LWheel.rotation.y = rotate_input

#var body_tilt = 35
#	# tilt body for effect
#var t = -rotate_input * ball.linear_velocity.length() / body_tilt
#body_mesh.rotation.z = lerp(body_mesh.rotation.z, t, 10 * delta)


#func _integrate_forces(state):
#    if updatingposition:
#        if assignedasocket:
#            followtarget = player.orbtargets[orbindex]
#            var direction = (followtarget.global_position - global_position).normalized()
#            var distance_to_player = global_position.distance_to(followtarget.global_position)
#            if distance_to_player > 10 :
#                apply_central_impulse(direction * 700)   

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

func find_closest_touche():
	if touche.size() <1:
		return null
	elif touche.size() >1:
		var distance = INF
		var closest = touche[0]
		for n in touche:
			var new_distance = n.global_translation.distance_to(global_translation)
			if new_distance < distance:
				distance = new_distance
				closest = n
			return closest
	else:
		return touche[0]



func _on_Scoreballcol_body_entered(body):
#	for index in get_slide_count():
#		var collision = get_slide_collison(index)
	if body is RigidBody:
#		var location = child.rect_global_position
#		old_parent_node.remove_child(child) new_parent_node.add_child(child)
#		child.rect_global_position = location
		
		#might not work but maybe. goal is to get position of specific object then apply that to the ball
#		var target = $Kart/Camera_pivot
		
#		var target_position = target.get_global_transform().origin
#    look_follow(state, get_global_transform(), target_position)
#    add_central_force(Vector3(0,0,5))

#		target.linear_velocity = (player - global_transform.origin) * sped
#		_physics_process(target * sped)
#		safe_look_at(player_position, Vector3.FORWARD)
#		safe_look_at(player, target.global_transform.origin)
		print("Boo.")
		#apply_centeral_impulse(Vector3(100,0,0)* _delta)
#	if body.is_in_group("players"):
#		print("body")
		
#func _on_body_enter(body):
#    if body.get_name() == "Player":
#        set_input_process(true)


