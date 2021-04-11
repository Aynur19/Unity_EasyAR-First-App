using System.Collections.Generic;
using System.Linq;

using UnityEngine;

/// <summary>
/// Скрипт изменения цели и его дочерних элементов.
/// </summary>
public class TargetBehaviour : MonoBehaviour
{
    /// <summary>
    /// Общее количество AR-объектов.
    /// </summary>
    private int targetObjectsARCount;

    /// <summary>
    /// Индекс текущего активного AR-объекта.
    /// </summary>
    private int currentIndexObjectAR;

    /// <summary>
    /// Начальный метод после инициализации объекта.
    /// </summary>
    void Start()
    {
        this.ComponentsInitialize();
    }

    /// <summary>
    /// Обновление перед выводом нового фрейма.
    /// </summary>
    void Update()
    {

    }

    private void ComponentsInitialize()
	{
        targetObjectsARCount = this.transform.childCount;
        var targetObjectsAR = new List<GameObject>();
        for(int i = 0; i < targetObjectsARCount; i++)
        {
            targetObjectsAR.Add(this.transform.GetChild(i).gameObject);
        }
        if(targetObjectsAR.Count > 0)
        {
            currentIndexObjectAR = targetObjectsAR.IndexOf(targetObjectsAR.SingleOrDefault(objectAR => objectAR.activeSelf));
        }
    }

    /// <summary>
    /// Обработчик нажатия по кнопке 'Next Object AR' в меню.
    /// </summary>
    public void OnClickMenuNextObjectAR()
	{
        this.SelectNextObjectAR();
    }

    /// <summary>
    /// Обработчик нажатия по кнопке 'Random Color' в меню.
    /// </summary>
    public void OnClickRandomColor()
    {
        if(currentIndexObjectAR >= 0 && currentIndexObjectAR < targetObjectsARCount)
        {
            SetRandomColor(this.transform.GetChild(currentIndexObjectAR).gameObject);
        }
    }

    /// <summary>
    /// Выбор следующего AR-объекта.
    /// </summary>
    public void SelectNextObjectAR()
	{
        var prevIndexObjectAR = currentIndexObjectAR;
        currentIndexObjectAR++;

		if(currentIndexObjectAR >= targetObjectsARCount)
		{
            currentIndexObjectAR = 0;
		}

		if(prevIndexObjectAR >= 0 && prevIndexObjectAR < targetObjectsARCount)
		{
            this.transform.GetChild(prevIndexObjectAR).gameObject.SetActive(false);
		}

        this.transform.GetChild(currentIndexObjectAR).gameObject.SetActive(true);
    }

    /// <summary>
    /// Установка рандомного цвета в материал текущего AR-объекта.
    /// </summary>
    /// <param name="objectAR">AR-объект цели.</param>
    public void SetRandomColor(GameObject objectAR)
	{
        objectAR.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
