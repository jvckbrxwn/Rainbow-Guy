 #pragma strict
  
public var colors : Color[];
 
private var ps : ParticleSystem;
private var particles : ParticleSystem.Particle[];
  
function Start() {
    ps = GetComponent.<ParticleSystem>();
    particles = new ParticleSystem.Particle[ps.maxParticles];
}
  
function Update() {
    var count = ps.GetParticles(particles);
    for (var i = 0; i < count; i++) {
        var c = particles[i].color;
        if (c.r > 0.99 && c.g > 0.99 && c.b > 0.99) {
            particles[i].color = colors[Random.Range(0,colors.Length)];
        }
    }
    ps.SetParticles(particles, count);
}