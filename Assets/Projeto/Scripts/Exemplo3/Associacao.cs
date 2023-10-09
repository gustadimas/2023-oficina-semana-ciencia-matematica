using UnityEngine;

public class Associacao : MonoBehaviour
{
    public Transform pecaCorretaTransform;
    public ArrasteComRotacao scriptPecaCorreta;
    public VerificadorVitoria scriptVerificadorVitoria;
    public int variacaoAnguloMaximoPermitido = 5;
    bool pecaNoLugar = false;

    void Update()
    {
        if(pecaNoLugar) return;

        if(Vector2.Distance(transform.position, pecaCorretaTransform.position) < 0.25f && VerificarSeAnguloEstaNosLimitesPermitidos())
        {
            // Ajusta a posição e rotação da peça para que ela fique exatamente no lugar correto.
            pecaCorretaTransform.position = transform.position;
            pecaCorretaTransform.rotation = transform.rotation;
            
            // Registra que a peça está no lugar correto.
            scriptVerificadorVitoria.RegistrarPecaNoLugar();
            
            // Desativa o script de arraste e rotação da peça.
            Destroy(scriptPecaCorreta);                        
            
            // Registra que a peça está no lugar correto.
            pecaNoLugar = true;
        }
    }

    // Como a rotação não é perfeita, é necessário verificar se o ângulo está dentro de um intervalo.
    bool VerificarSeAnguloEstaNosLimitesPermitidos()
    {
        float anguloLocalAssociacao = transform.rotation.eulerAngles.z;
        float anguloPecaCorreta = pecaCorretaTransform.rotation.eulerAngles.z;

        float diferencaAngular = Mathf.DeltaAngle(anguloLocalAssociacao, anguloPecaCorreta);

        // Verifica se a diferença angular está dentro do intervalo permitido
        return Mathf.Abs(diferencaAngular) <= variacaoAnguloMaximoPermitido;
    }

}
