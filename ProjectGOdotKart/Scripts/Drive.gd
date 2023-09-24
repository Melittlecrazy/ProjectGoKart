extends Spatial

onready var ball = $Ball
onready var car_mesh = $Kart
onready var ground_ray = $Kart/RayCast

var sphere_offset = Vector3(0,-0.1,0)
var acceleration = 50
var steering = 21.0
var turn_speed = 5
var turn_stop_limit = 0.75

var speed_input = 0
var rotate_input = 0

func _ready():
	ground_ray.add_exception(ball)
	
func _physics_process(_delta):
	# Keep the car mesh aligned with the sphere
	car_mesh.transform.origin = ball.transform.origin + sphere_offset
	# Accelerate based on car's forward direction
	ball.add_central_force(-car_mesh.global_transform.basis.z * speed_input)
	

func _process(delta):
	# Can't steer/accelerate when in the air
	if not ground_ray.is_colliding():
		return
	# Get accelerate/brake input
	speed_input = 0
	speed_input += Input.get_action_strength("accelerate")
	speed_input -= Input.get_action_strength("brake")
	speed_input *= acceleration
	# Get steering input
	rotate_input = 0
	rotate_input += Input.get_action_strength("steer_left")
	rotate_input -= Input.get_action_strength("steer_right")
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
onready var F_RWheel = $Kart/F_R_Wheel
onready var F_LWheel = $Kart/F_LWheel
#F_RWheel.rotation.y = rotate_input
#F_LWheel.rotation.y = rotate_input

#var body_tilt = 35
#	# tilt body for effect
#var t = -rotate_input * ball.linear_velocity.length() / body_tilt
#body_mesh.rotation.z = lerp(body_mesh.rotation.z, t, 10 * delta)

func _on_Scoreballcol_body_entered(body):
#	for index in get_slide_count():
#		var collision = get_slide_collison(index)
#	if collision.collider is RigidBody:
		print("Boo.")
		
#func _on_body_enter(body):
#    if body.get_name() == "Player":
#        set_input_process(true)
