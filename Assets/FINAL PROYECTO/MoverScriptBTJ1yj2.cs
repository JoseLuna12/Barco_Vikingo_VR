using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TechTweaking.Bluetooth;

public class MoverScriptBTJ1yj2 : MonoBehaviour {

    private BluetoothDevice device;
    public Text statusText;
    public Text j1, j2, barcotxt;

    float barcoMovLagLess;
    int eje, ahora, antes;
    int eje2, ahora2, antes2;
    bool adelante1, adelante2, atras1, atras2;
    int giro, mover, mover2, moverBarco;


    public Transform cube;
    public Transform cube2;
    public Transform b;

    Rigidbody rb;

    public float speed = 1.0f;

    void Awake()
    {
        statusText.text = "Status : ...";

        BluetoothAdapter.enableBluetooth();//Force Enabling Bluetooth


        device = new BluetoothDevice();


        device.Name = "HC-05";

        device.setEndByte(255);

        device.ReadingCoroutine = ManageConnection;

        connect();


    }

    void Start()
    {
        rb = b.GetComponent<Rigidbody>();
    }

    public void connect()
    {
        device.connect();
    }

    public void disconnect()
    {
        device.close();
    }

    IEnumerator ManageConnection(BluetoothDevice device)
    {
        statusText.text = "Status : Connected & Can read";
        while (device.IsConnected && device.IsReading)
        {

            //polll all available packets
            BtPackets packets = device.readAllPackets();

            if (packets != null)
            {

                int N = packets.Count - 1;

                int indx = packets.get_packet_offset_index(N);
                int size = packets.get_packet_size(N);



                if (size == 8)
                {

                    // packets.Buffer[indx] equals lowByte(x1) and packets.Buffer[indx+1] equals highByte(x2)
                    int val1 = (packets.Buffer[indx + 1] << 8) | packets.Buffer[indx];
                    //Shift back 3 bits, because there was << 3 in Arduino
                    val1 = val1 >> 3;

                    int val2 = (packets.Buffer[indx + 3] << 8) | packets.Buffer[indx + 2];
                    //Shift back 3 bits, because there was << 3 in Arduino
                    val2 = val2 >> 3;

                    int val3 = (packets.Buffer[indx + 5] << 8) | packets.Buffer[indx + 4];
                    val3 = val3 >> 3;

                    int val4 = (packets.Buffer[indx + 7] << 8) | packets.Buffer[indx + 6];
                    val4 = val4 >> 3;

                    //#########Converting val1, val2 into something similar to Input.GetAxis (Which is from -1 to 1)#########
                    //since any val is from 0 to 1023
                    float Axis1 = ((float)val1 / 1023f) * 2f - 1f;
                    if (Axis1 <= 1 && Axis1 >= 0.75)
                        eje = 2;

                    if (Axis1 >= -1 && Axis1 <= -0.75)
                        eje = 4;
                    float Axis2 = ((float)val2 / 1023f) * 2f - 1f;
                    if (Axis2 <= 1 && Axis2 >= 0.85)
                        eje = 1;

                    if (Axis2 >= -1 && Axis2 <= -0.85)
                        eje = 3;

                    if (Axis1 <= 0.8 && Axis1 >= -0.6 && Axis2 <= 0.8 && Axis2 >= -0.6)
                        eje = 0;

                    if (eje == 0)
                    {
                        ahora = 0;
                        antes = 0;
                    }

                    if (ahora == eje)
                    {
                        ahora = ahora;
                    }
                    else if (ahora != eje)
                    {
                        antes = ahora;
                        ahora = eje;
                    }

                    if (antes == 1 && ahora == 2 || antes == 2 && ahora == 3 || antes == 3 && ahora == 4 || antes == 4 && ahora == 1)
                    {
                        j2.text = "adelante true j1";
                        adelante1 = true;
                        atras1 = false;
                        //direccion1 = "adelante";
                        //direccion.text = "la direccion es adelante";
                        mover = 5;
                    }

                    else if (antes == 1 && ahora == 4 || antes == 4 && ahora == 3 || antes == 3 && ahora == 2 || antes == 2 && ahora == 1)
                    {
                        j2.text = "atras true j1";
                        atras1 = true;
                        adelante1 = false;
                        //direccion1 = "atras";
                        //direccion.text = "la direccion es atras";
                        mover = -5;
                    }
                    if (antes == 0 && ahora == 0)
                    {
                        j2.text = "j1 sin mover";
                        atras1 = false;
                        adelante1 = false;

                        //direccion1 = "ND";
                        mover = 0;
                        //direccion.text = "sin movimineto";
                    }


                    float Axis3 = ((float)val3 / 1023f) * 2f - 1f;
                    if (Axis3 <= 1 && Axis3 >= 0.85)
                        eje2 = 2;
                    if (Axis3 >= -1 && Axis3 <= -0.85)
                        eje2 = 4;


                    float Axis4 = ((float)val4 / 1023f) * 2f - 1f;
                    if (Axis4 <= 1 && Axis4 >= 0.75)
                        eje2 = 1;

                    if (Axis4 >= -1 && Axis4 <= -0.75)
                        eje2 = 3;

                    if (Axis3 <= 0.8 && Axis3 >= -0.6 && Axis4 <= 0.8 && Axis4 >= -0.6)
                        eje2 = 0;


                    if (eje2 == 0)
                    {
                        ahora2 = 0;
                        antes2 = 0;
                    }

                    if (ahora2 == eje2)
                    {
                        ahora2 = ahora2;
                    }
                    else if (ahora2 != eje2)
                    {
                        antes2 = ahora2;
                        ahora2 = eje2;
                    }

                    if (antes2 == 1 && ahora2 == 2 || antes2 == 2 && ahora2 == 3 || antes2 == 3 && ahora2 == 4 || antes2 == 4 && ahora2 == 1)
                    {
                        j1.text = "j2 adelante true";
                        adelante2 = true;
                        atras2 = false;
                        //direccionj2 = "adelante";
                        //direccion2.text = "la direccion es adelante";
                        mover2 = 5;
                    }
                    else if (antes2 == 1 && ahora2 == 4 || antes2 == 4 && ahora2 == 3 || antes2 == 3 && ahora2 == 2 || antes2 == 2 && ahora2 == 1)
                    {
                        j1.text = "j2 atras true";
                        atras2 = true;
                        adelante2 = false;
                        //direccionj2 = "atras";
                        //direccion2.text = "la direccion es atras";
                        mover2 = -5;
                    }

                    if (antes2 == 0 && ahora2 == 0)
                    {
                        j1.text = "sin mover j2";
                        atras2 = false;
                        adelante2 = false;
                        //direccionj2 = "ND";
                        mover2 = 0;
                        //direccion2.text = "sin movimineto";
                    }

                    //movimiento del barco

                    if (adelante1 && adelante2)
                    {
                        moverBarco = -1;
                        giro = 0;
                        barcotxt.text = "adelante " + moverBarco.ToString();
                        
                    }
                    else if (atras1 && atras2)
                    {
                        moverBarco = 1;
                        giro = 0;
                        barcotxt.text = "atras " + moverBarco.ToString();
                        
                    }
                    else { moverBarco = 0;
                        barcotxt.text = "SN";
                    }


                    if (moverBarco == 0 && adelante1 == true)
                    {
                        giro = 1;
                        
                    }
                    else if (moverBarco == 0 && adelante2 == true)
                    {
                        giro = -1;
                       
                    }
                    else if (moverBarco > 0 || moverBarco < 0 || adelante1 == false || adelante2 == false)
                    {
                        giro = 0;
                    }
                    else
                    {
                        giro = 0;
                    }

                    
                    //GirarCubo(b, giro);
                    //MoveCube(cube, 0, mover);
                    //MoveCube(cube2, 0, mover2);

                }


            }

            yield return null;
        }

        statusText.text = "Status : Done Reading";

    }

    private void Update()
    {
        MoveCube(b, moverBarco);
        GirarCubo(b, giro);

    }
    
    private void MoveCube(Transform cube, int x)
    {
        
        //barcoMovLagLess = Mathf.Lerp(barcoMovLagLess, x, Time.deltaTime * 30);
        //cube.transform.Translate(barcoMovLagLess * (1), 0, 0);

        Vector3 moveVector = new Vector3(x, 0, 0);
        cube.transform.Translate(moveVector, Space.Self);

    }

    private void GirarCubo(Transform cube, int d)
    {
        Vector3 rotDir = new Vector3(0, d, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotDir * Time.deltaTime*5);
        //cube.transform.Rotate(Vector3.up * Time.deltaTime * d);

        rb.MoveRotation(rb.rotation * deltaRotation);

    }


}
