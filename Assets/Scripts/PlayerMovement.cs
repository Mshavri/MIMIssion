using UnityEngine;

// سكربت بسيط لتحريك اللاعب وربط الحركة بالأنميشن
public class PlayerMovement : MonoBehaviour
{
    public Animator anim;      // الأنميتر المرتبط بالشخصية
    public float moveSpeed;    // سرعة الحركة

    private Rigidbody2D rb;    // الفيزياء (الحركة الفعلية)
    private Vector2 input;     // اتجاه الحركة
    private bool moving;       // هل اللاعب يتحرك ولا واقف

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // نجيب الـ Rigidbody2D من نفس الأوبجكت
    }

    private void Update()
    {
        GetInput();  // نقرأ الأزرار
        Animate();   // نحدث الأنميشن
    }

    private void FixedUpdate()
    {
        // نحرك اللاعب بالفيزياء بناءً على الاتجاه والسرعة
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        // نقرأ المحاور من الكيبورد (يمين يسار فوق تحت)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // نخزن الاتجاه ونطبّع طوله (عشان ما تكون السرعة أقوى بالقطر)
        input = new Vector2(x, y).normalized;
    }

    private void Animate()
    {
        // إذا فيه حركة نعتبر اللاعب يتحرك
        moving = input.sqrMagnitude > 0.01f;

        // نرسل الاتجاه للأنميتر لما يكون اللاعب يتحرك
        if (moving)
        {
            anim.SetFloat("X", input.x);
            anim.SetFloat("Y", input.y);
        }

        // نرسل حالة الحركة (واقِف / يمشي)
        anim.SetBool("Moving", moving);
    }
}
