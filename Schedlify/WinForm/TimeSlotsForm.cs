using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Schedlify.Controllers;
using Schedlify.Global;
using Schedlify.Models;
using Schedlify.Utils;

namespace Schedlify.WinForm
{
    public partial class TimeSlotsForm : Form
    {
        private List<Slot> _slotList; // Локальний список для редагування
         // Публічний доступ до списку як IEnumerable

        private readonly TemplateSlotController _templateSlotController;

        public TimeSlotsForm()
        {
            InitializeComponent();
            _slotList = new List<Slot>();
            _templateSlotController = new TemplateSlotController();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Конвертуємо DateTime у TimeOnly
            TimeOnly startTime = TimeOnly.FromDateTime(dateTimePicker1.Value);
            TimeOnly endTime = TimeOnly.FromDateTime(dateTimePicker2.Value);

            // Перевіряємо, що початковий час менший за кінцевий
            if (startTime < endTime)
            {
                Slot newSlot = new Slot { startTime = startTime, endTime = endTime }; // Використання TimeOnly
                _slotList.Add(newSlot);
                UpdateSlotListDisplay();
            }
            else
            {
                MessageBox.Show("Стартовий час має бути меншим за кінцевий!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (SlotList.SelectedItem != null)
            {
                int selectedIndex = SlotList.SelectedIndex;
                _slotList.RemoveAt(selectedIndex);
                UpdateSlotListDisplay();
            }
            else
            {
                MessageBox.Show("Оберіть слот для видалення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (SlotList.SelectedItem != null)
            {
                int selectedIndex = SlotList.SelectedIndex;

                // Оновлюємо значення у списку
                _slotList[selectedIndex].startTime = TimeOnly.FromDateTime(dateTimePicker1.Value);
                _slotList[selectedIndex].endTime = TimeOnly.FromDateTime(dateTimePicker2.Value);

                UpdateSlotListDisplay();
            }
            else
            {
                MessageBox.Show("Оберіть слот для редагування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (_slotList.Count > 0)
            {
                // Перевірка на коректність часу перед додаванням
                if (!AreSlotsValid(_slotList))
                {
                    MessageBox.Show("Часові проміжки некоректні! Перевірте вказаний час.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Дозволимо користувачу виправити введені дані, не зупиняючи виконання
                    return; // Повертаємося до введення даних, без переходу
                }

                // Якщо всі слоти коректні, додаємо їх через контролер
                _templateSlotController.AddTemplateSlots(UserSession.currentDepartment.Id, _slotList);

                // Перехід до наступної форми
                ClassesForm classesForm = new ClassesForm();
                classesForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Додайте хоча б один слот часу перед переходом!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AreSlotsValid(List<Slot> slots)
        {
            // Перевірка кожного слота: чи стартовий час раніше за кінцевий
            foreach (var slot in slots)
            {
                if (slot.startTime >= slot.endTime)
                {
                    MessageBox.Show("Стартовий час має бути меншим за кінцевий!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Перевірка на перетини між слотами
            for (int i = 0; i < slots.Count; i++)
            {
                for (int j = i + 1; j < slots.Count; j++)
                {
                    // Якщо слоти перетинаються
                    if (SlotsOverlap(slots[i], slots[j]))
                    {
                        MessageBox.Show("Часові слоти перетинаються! Перевірте їх та виправте.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool SlotsOverlap(Slot slot1, Slot slot2)
        {
            // Перевірка, чи перетинаються два слоти
            return slot1.startTime < slot2.endTime && slot2.startTime < slot1.endTime;
        }


        private void UpdateSlotListDisplay()
        {
            SlotList.Items.Clear();
            foreach (var slot in _slotList)
            {
                SlotList.Items.Add($"{slot.startTime:HH\\:mm} - {slot.endTime:HH\\:mm}");
            }
        }
    }
}
