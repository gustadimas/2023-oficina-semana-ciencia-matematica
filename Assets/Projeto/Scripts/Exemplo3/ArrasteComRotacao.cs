using UnityEngine;

public class ArrasteComRotacao : MonoBehaviour
{
    Vector3 deslocamento;
    Vector3 posicaoDoMouse;

    bool arrastandoImagem = false;
    bool interagiuComAImagem = false;

    void OnMouseDown()
    {
        deslocamento = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        arrastandoImagem = true;
        VerificarSeInteragiuComAImagem();
    }

    void OnMouseDrag()
    {    
        if (arrastandoImagem)
        {
            posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float posicaoEmX = posicaoDoMouse.x + deslocamento.x;
            float posicaoEmY = posicaoDoMouse.y + deslocamento.y;
            float posicaoEmZ = transform.position.z;

            transform.position = new Vector3(
                posicaoEmX, posicaoEmY, posicaoEmZ);
        }
    }

    void OnMouseUp()
    {
        arrastandoImagem = false;
    }

    void VerificarSeInteragiuComAImagem()
    {
        posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (GetComponent<Collider2D>().OverlapPoint(posicaoDoMouse))        
            interagiuComAImagem = true;
        else        
            interagiuComAImagem = false;        
    }

    void Update()
    {
        RotacionarImagem();
    }

    void RotacionarImagem()
    {
        if (arrastandoImagem) return;

        if (Input.GetKey(KeyCode.R) && interagiuComAImagem)
        {
            float anguloDeRotacao = Input.GetAxis("Mouse X") * 10;
            transform.Rotate(0, 0, anguloDeRotacao);
        }
        else                    
            interagiuComAImagem = false;        
    }

}
