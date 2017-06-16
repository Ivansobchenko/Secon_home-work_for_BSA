# Second_home-work_for_BSA
Зоопарк

Написать консольное приложение, которое имитирует базовую работу зоопарка. В зоопарке должны жить несколько видов животных: лев, тигр, слон, медведь, волк, лиса. У каждого животного должны быть следующие характеристики: Здоровье (лев - 5 очков, тигр - 4 очка, слон - 7 очков, медведь - 6 очков, волк - 4 очка, лиса - 3 очка) Состояние (Сыт, Голоден, Болен, Мертв) Кличка

Программа должна быть интерактивной и ожидать от пользователя команды:

Добавить животное (после добавления животное имеет Состояние Сыт) - в параметрах передать имя и вид

Покормить животное - в параметрах передать Кличку

Вылечить животное - в параметрах передать Кличку (увеличивает Здоровье на 1, но не больше, чем начальное Здоровье)

Удалить животное из зоопарка (только если животное мертво, иначе ничего не делать)

Вывести пользователю результат каждой команды.

Реализовать механизм, который будет каждый 5 секунд выбирать случайное животное и менять ему состояние в следующем порядке Сыт -> Голоден -> Болен. Если животное было в состоянии Болен, то отнимать одно очко здоровья. Когда Здоровье будет равно 0, перейти в состояние Мертв. Если все животные в зоопарке мертвы, вывести сообщение и завершить программу.

Использовать принципы ООП, практики хорошего кода, оптимальные возможности языка. Желательно использовать паттерны проектирования: фабрика, команда (стратегия), репозиторий.

Расширить второе задание, добавив возможность выбирать данные с помощью LINQ. Список методов должен быть либо внутри репозитория (если был использован в первом задании) либо в отдельном классе. Примеры методов должны быть вызваны из консоли.

Показать всех животных, сгруппированных по виду животного
Показать животных по состоянию - в параметрах передать Состояние
Показать всех тигров, которые больны
Показать слона с определенной кличкой, которая задается в параметре
Показать список всех кличек животных, которые голодны
Показать самых здоровых животных каждого вида (по одному на каждый вид)
Показать количество мертвых животных каждого вида
Показать всех волков и медведей, у которых здоровье выше 3
Показать животное с максимальным здоровьем и животное с минимальным здоровьем (описать одним выражением)
Показать средней количество здоровья у животных в зоопарке
