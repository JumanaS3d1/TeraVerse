using UnityEngine;
using BNG;


    public class BubbleEmitter : MonoBehaviour
    {
        public ParticleSystem bubbleParticleSystem;  // Reference to the Particle System
        public Transform handTransform;              // Reference to the hand controller transform
        public float minSpeedThreshold = 0.1f;       // Minimum speed to start emitting bubbles
        public float maxSpeedThreshold = 2.0f;       // Maximum speed for maximum emission rate

        private Vector3 lastPosition;
        private ParticleSystem.EmissionModule emissionModule;
        protected InputBridge input;
    public AudioSource waterSFX;

        public ControllerHand controller;

        void Start()
        {
              input = InputBridge.Instance; 
            if (bubbleParticleSystem == null)
            {
                Debug.LogError("Bubble Particle System not assigned!");
                return;
            }

            emissionModule = bubbleParticleSystem.emission;
            lastPosition = handTransform.position;
        }

        void Update()
        {
            // Calculate hand speed
            Vector3 currentPosition = handTransform.position;
            float speed = (currentPosition - lastPosition).magnitude / Time.deltaTime;
            lastPosition = currentPosition;

            // Adjust emission rate based on speed
            if (speed < minSpeedThreshold)
            {
                emissionModule.rateOverTime = 0;
            }
            else
            {
                float normalizedSpeed = Mathf.Clamp01((speed - minSpeedThreshold) / (maxSpeedThreshold - minSpeedThreshold));
                emissionModule.rateOverTime = Mathf.Lerp(0, 100, normalizedSpeed);  // Adjust 100 to your desired max emission rate
                input.VibrateController(2f, 3f, .2f, controller);
            print(normalizedSpeed);
            if (normalizedSpeed > 0.5) {
                waterSFX.Play();
            }
            }
        }
    }

