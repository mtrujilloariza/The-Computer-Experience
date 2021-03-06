﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayController : MonoBehaviour
{
    public Element elementPrefab; 
    public int arraySize;
    public int elementPadding;
    private Element[] array;
    public string[] labels;
    public int[] values; 

    public void generateArray(){
        int x = 0;
        int mid = (arraySize - 1) / 2; 
        array = new Element[arraySize];

        if (arraySize % 2 == 0){
            Element e;
            int j = 0;
            for(int i = 0; i < arraySize; i += 2){
                if (i == 0){
                    x += (elementPadding / 2);
                } else {
                    x += (elementPadding);
                }   

                e = Instantiate(elementPrefab); 
                array[mid - j] = e;
                e.transform.position = new Vector2(-x, this.transform.position.y);

                e = Instantiate(elementPrefab);
                j++;
                array[mid + j] = e;
                e.transform.position = new Vector2(x, this.transform.position.y);

 
            }
            
        } else {

            Element e = Instantiate(elementPrefab);
            e.transform.position = new Vector2(x, this.transform.position.y);
            array[mid] = e;
            int j = 1;

            for (int i = 1; i < arraySize; i+=2){
                x += elementPadding;
                
                e = Instantiate(elementPrefab);
                array[mid + j] = e;
                e.transform.position = new Vector2(x, this.transform.position.y);

                e = Instantiate(elementPrefab);
                array[mid - j] = e;
                e.transform.position = new Vector2(-x, this.transform.position.y);

                j++;
            }

        }
    }

    public void fillArray(){
        if (arraySize == labels.Length && arraySize == values.Length){
            for (int i = 0; i < arraySize; i++){
                Element e = array[i];
                e.setText(labels[i]);
                e.setValue(values[i]);
            }
        } else {
            Debug.Log("different size arrays for element array and values or lables array");
        }
    }

    public Element GetElement(int index){
        return array[index];
    }

    public void swap(int i, int j){
        Vector2 iVector = array[i].transform.position;
        Vector2 jVector = array[j].transform.position;

        array[i].transform.position = jVector;
        array[j].transform.position = iVector;

        Element temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public void setBlue(Element e){
        e.setBlue();
    }

    public void setRed(Element e){
        e.setRed();
    }

    public void setClear(Element e){
        e.setClear();
    }

    public void setGreen(Element e){
        e.setGreen();
    }

    public void setYellow(Element e){
        e.setYellow();
    }

    public int[] getValues(){
        int[] valueArray = new int[arraySize];
        for(int i = 0; i < arraySize; i++){
            valueArray[i] = this.array[i].getValue();
        }
        return valueArray;
    }

    public void deleteArray(){
        foreach(Element e in array){
            e.delete();
        }
    }

    public Element[] getArray(){
        return array;
    }
}
