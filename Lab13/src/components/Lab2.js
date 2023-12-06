import React, { useState } from 'react';

const TalkativenessLab = () => {
  const [inputData, setInputData] = useState('');
  const [minMaxDifference, setMinMaxDifference] = useState('');

  const handleInputChange = (event) => {
    setInputData(event.target.value);
  };

  const calculateMinMaxDifference = () => {
    const data = inputData.split(/\s+/).map(num => parseInt(num, 10));
    if (data.length > 1 && data.every(num => !isNaN(num))) {
      setMinMaxDifference(findMinMaxDifference(data));
    } else {
      setMinMaxDifference('Некоректні вхідні дані');
    }
  };

  const findMinMaxDifference = (data) => {
    const n = data[0];
    const talkativeness = data.slice(1);

    if (talkativeness.length === n) {
      talkativeness.sort((a, b) => a - b);
      const minMaxDiff = talkativeness[n - 1] - talkativeness[0];
      return minMaxDiff.toString();
    } else {
      return 'Невідповідність розміру даних';
    }
  };

  return (
    <div className="container">
      <h1>Лабораторна робота 2</h1>
      <h2>Умова задачі:</h2>
      <p>Назвемо балакучістю групи різницю між максимальним і мінімальним
рівнями балакучості стареньких у групі. Наприклад, якщо рівні балакучості
стареньких у групі рівні 7, 3 і 11, то балакучість групи дорівнює 11 - 3 = 8.
Балакучістю розбиття стареньких на групи назвемо максимальну з балакучих
груп, що входять в розбиття.
Потрібно написати програму, яка допоможе Івану Івановичу знайти розбиття
бабусь на групи, балакучість якого мінімальна.</p>
      <h2>Вхідні дані</h2>
      <p>Вхідний файл INPUT.TXT містить у першому рядку число N (2 ≤ N ≤ 1000) –
кількість стареньких. У другому рядку записано N чисел від 1 до 109 –
балакучості стареньких</p>
      <h2>Вихідні дані:</h2>
      <p>Вихідний текстовий файл OUTPUT.TXT повинен містити одне ціле число, що
дорівнює мінімально можливої балакучості розбиття стареньких на групи</p>
        <h2>Приклад:</h2>
      <p>INPUT: 3 1 2 3</p>
      <p>OUTPUT: 2</p>
      <form>
        <div className="form-group">
          <label htmlFor="Input">Введіть кількість людей та їх балакучість:</label>
          <textarea value={inputData} onChange={handleInputChange} className="form-control" id="Input" />
        </div>
        <button type="button" onClick={calculateMinMaxDifference} className="btn">Обчислити</button>
      </form>

      {minMaxDifference && (
        <div className="form-group">
          <label htmlFor="Output">Результат (мінімальна різниця):</label>
          <input type="text" value={minMaxDifference} className="form-control" id="Output" readOnly />
        </div>
      )}
    </div>
  );
};

export default TalkativenessLab;
