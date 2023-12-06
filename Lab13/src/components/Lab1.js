import React, { useState } from 'react';

const SatelliteNumbersLab = () => {
  const [inputData, setInputData] = useState('');
  const [result, setResult] = useState('');

  const handleInputChange = (event) => {
    setInputData(event.target.value);
  };

  const calculateSatelliteNumbers = () => {
    const [s, k] = inputData.split(' ').map(num => parseInt(num, 10));
    if (!isNaN(s) && !isNaN(k)) {
      const response = satelliteResponse(s, k);
      setResult(`${response.max} ${response.min}`);
    } else {
      setResult('Некоректні вхідні дані');
    }
  };

  const satelliteResponse = (s, k) => {
    let maxNumber = Array(k).fill('0');
    let minNumber = Array(k).fill('0');
    let remainingSum = s;

    // Формування максимального числа
    for (let i = 0; i < k; i++) {
        if (remainingSum > 9) {
            maxNumber[i] = '9';
            remainingSum -= 9;
        } else {
            maxNumber[i] = String(remainingSum);
            remainingSum = 0;
            break;
        }
    }

    remainingSum = s;

    // Формування мінімального числа
    for (let i = k - 1; i >= 0; i--) {
        if (remainingSum > 9) {
            minNumber[i] = '9';
            remainingSum -= 9;
        } else {
            if (i === 0) {
                minNumber[i] = String(remainingSum);
            } else {
                minNumber[i] = String(remainingSum - 1);
                minNumber[0] = '1';
                break;
            }
        }
    }

    return { max: maxNumber.join(''), min: minNumber.join('') };
  };

  return (
    <div className="container">
      <h1>Лабораторна робота 1</h1>
      <h2>Умова задачі:</h2>
      <p> Сьогодні в космосі знаходяться сотні супутників, і всі вони обмінюються даними. При
 цьому система розпізнавання сигналів працює за схемою "Свій-Чужий". Один із супутників
 відправляє запит іншому супутнику у форматі двох цілих чисел, а другий супутник
 відповідає першому так само двома цілими числами. Перші два числа першого супутника є
 сумою цифр і кількість цифр тих двох чисел, якими повинен відповісти другий супутник.
 При цьому як відповідь повинні вийти числа, що становлять найбільше і найменше можливі
 значення, які можуть бути сформовані за описаним вище методом.
 Ви маєте написати програму, яка формує відповідь для другого супутника за відомими
 числами, отриманими від першого супутника.</p>
      <h2>Вхідні дані</h2>
      <p>У вхідному файлі INPUT.TXT записані 2 натуральні числа S і K, що представляють суму та
кількість цифр відповідно (K ≤ 100). При цьому гарантується, що можна скласти хоча б одне
K-значне число, сума цифр якого дорівнює S.</p>
      <h2>Вихідні дані:</h2>
      <p>У вихідний файл OUTPUT.TXT виведіть два числа – відповідь другого супутника. При
цьому слід пам'ятати, що всі числа не мають нулів, що лідирують.</p>
        <h2>Приклад:</h2>
      <p>INPUT: 1 3</p>
      <p>OUTPUT: 100 100</p>
      <form>
        <div className="form-group">
          <label htmlFor="Input">Введіть числа S і K (розділені пробілом):</label>
          <input type="text" value={inputData} onChange={handleInputChange} className="form-control" id="Input" />
        </div>
        <button type="button" onClick={calculateSatelliteNumbers} className="btn">Обчислити</button>
      </form>

      {result && (
        <div className="form-group">
          <label htmlFor="Output">Результат:</label>
          <input type="text" value={result} className="form-control" id="Output" readOnly />
        </div>
      )}
    </div>
  );
};

export default SatelliteNumbersLab;
