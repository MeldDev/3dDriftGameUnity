using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class Localization : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset _englishFont;
    [SerializeField] private TMP_FontAsset _russianFont;
    [SerializeField] private TMP_FontAsset _ukraineFont;
    [SerializeField] private LanguageList _language;
    public delegate void LocalizationDelegate();
    public LocalizationDelegate localizationDelegate;

    Dictionary<string, string[]> _stringDictionary = new Dictionary<string, string[]>()
    {
        {"QUALITY", new string[]{ "QUALITY", "Качество", "Якiсть" } },
        {"LOW", new string[]{ "LOW", "Низкое", "Низьке" } },
        {"MEDIUM", new string[]{ "MEDIUM", "Среднее", "Середнє" } },
        {"HIGH", new string[]{ "HIGH", "Высокое", "Висока" } },
        {"Frame frequency", new string[]{ "Frame frequency", "Частота кадров", "Частота кадрiв" } },
        {"SHOW FPS COUNTER", new string[]{ "SHOW FPS COUNTER", "Счетчик кадров", "Лiчильник кадрiв" } },
        {"Language", new string[]{ "Language", "Язык", "Мова" }},
        {"MORE GAMES", new string[]{ "MORE GAMES", "БОЛЬШЕ ИГР", "БIЛЬШЕ IГР" }},
        {"Save Settings", new string[]{ "Save Settings", "Сохранить настройки", "Зберегти налаштування" }},
        {"Information", new string[]{ "Information", "Информация", "Iнформацiя" }},
        {"YOU LOSE", new string[]{ "YOU\nLOSE", "ВЫ\nПРОИГРАЛИ", "ВИ\nПРОГРАЛИ" }},
        {"SKIP", new string[]{ "SKIP", "ПРОПУСТИТЬ", "ПРОПУСТИТИ" }},
        {"watch ad to revive?", new string[]{ "watch ad to revive?", "посмотреть рекламу, чтобы продолжить?", "подивитися рекламу, щоб продовжити?" }},
        {"MAX DISTANCE", new string[]{ "MAX DISTANCE", "МАКСИМАЛЬНОЕ РАССТОЯНИЕ", "МАКСИМАЛЬНА ВІДСТАНЬ" }},
        {"TAP TO PLAY", new string[]{ "TAP TO\nPLAY", "Нажмите\nчтобы\nиграть", "Клацнiть\nщоб грати" }},
        {"TAP TO RESUME", new string[]{ "TAP TO\nRESUME", "Нажмите\nчтобы\nпродолжить", "Клацнiть\nщоб грати" }},
        {"answer1Text1", new string[]{ "Yes, of course!", "Да, Конечно!", "Так, звичайно!" }},
        {"answer1Text2", new string[]{ "I vaguely remember something.", "Что-то припоминаю.", "Щось пригадую." }},
        {"answer1Text3", new string[]{ "I've already forgotten something.", "Что-то уже и забылось.", "Щось уже забулося." }},
        {"answer2Text1", new string[]{ "Hmm, that's interesting!", "Хм, это интересно!", "Гм, це цікаво!" }},
        {"answer2Text2", new string[]{ "I want to take a look at the room.", "Хочу бы взглянуть на помещение.", "Хочу подивитись на приміщення." }},
        {"answer2Text3", new string[]{
            "I'm interested to see if it's\n" +
            "suitable. Let's take it before\n" +
            "anyone else gets ahead of us!",

            "Мне интересно увидеть, оно\n" +
            "может подойти. Забираем пока никто\n" +
            "никто не опередил нас!",

            "Цікаво побачити, чи підійде\n" +
            "це. Забираємо, поки ніхто\n" +
            "нас не випередив!" }},

        {"emiliaAnswer1", new string[]{ "Hi! Do you remember you asked\nme to find a place?", "Привет! Помнишь ты просил\nменя найти помещение?", "Привіт! Пам'ятаєш, ти просив\nмене знайти приміщення?" }},
        {"emiliaAnswer2", new string[]{ "There is an option. It's in a great neighborhood!", "Есть вариант. Оно в хорошем районе!", "Є варіант. Він знаходиться у хорошому районі!" }},
        {"emiliaAnswer3", new string[]{ "It's absolutely perfect\nfor your coffee shop!", "Для твоей кофейни просто супер!!!", "Для твоєї кав'ярні просто супер!!!" }},
        {"emiliaAnswer4", new string[]{ "However, there is a small catch.", "Правда есть небольшой нюанс.", "Проте, є невеликий нюанс." }},
        {"emiliaAnswer5", new string[]{ "The place is in need of some renovation.", "Помещение нуждается в хорошем ремонте.", "Приміщення потребує хорошого ремонту." }},
        {"emiliaAnswer6", new string[]{ "Great! I'll arrange a meeting for now,\nand meanwhile, we can choose\na name for the new coffee shop.", "Отлично, я пока устрою встречу,\nа пока можно выбрать название\nновой кофейни.", "Чудово! Зараз я організую зустріч,\nа поки ми можемо обрати назву\nдля нової кав'ярні." }},
        {"emiliaAnswer7", new string[]{ "The name is very important, but we\ncan always change it later if needed.", "Название очень важно, но если\nчто его можно потом поменять.", "Назва дуже важлива, але якщо що,\nми завжди можемо змінити її пізніше." }},
        {"enterNewMessage", new string[]{ "Enter you\nnew message here", "Введите ваше\nновое сообщение здесь", "Введіть ваше\nнове повідомлення тут" }},
        {"cafeOpening", new string[]{ "Cafe opening", "Открытие кафе", "Відкриття кафе" }},
        {"enterCoffeeShopName", new string[]{ "Enter coffee shop name", "Введите название кофейни", "Введіть назву кав'ярні" }},
        {"confirm", new string[]{ "Confirm", "Подтвердить", "Підтвердити" }},
        {"level", new string[]{ "Level", "Уровень", "Рівень" }},
        {"chooseCoffeeShopIcon", new string[]{ "Choose coffee shop icon", "Выберите иконку кофейни", "Оберіть іконку кав'ярні" }},
        {"recipeMenu", new string[]{ "Recipe menu", "Меню рецептов", "Меню рецептів" }},
        {"tea", new string[]{ "Tea", "Чай", "Чай" }},
        {"coffee", new string[]{ "Coffee", "Кофе", "Кава" }},
        {"cocoa", new string[]{ "Cocoa", "Какао", "Какао" }},
        {"juice", new string[]{ "Juice", "Сок", "Сік" }},
        {"cocktails", new string[]{ "Cocktails", "Коктейли", "Коктейлі" }},
        {"cake", new string[]{ "Cake", "Пирожное", "Торт" }},
        {"other", new string[]{ "Other", "Другое", "Інше" }},
        {"shop", new string[]{ "Shop", "Магазин", "Магазин" }},
        {"bank", new string[]{ "Bank", "Банк", "Банк" }},
        {"ingredients", new string[]{ "Ingredients", "Ингредиенты", "Інгредієнти" }},
        {"equipment", new string[]{ "Equipment", "Оборудование", "Обладнання" }},
        {"tables", new string[]{ "Tables", "Столы", "Столи" }},
        {"chairs", new string[]{ "Chairs", "Стулья", "Стільці" }},
        {"emilia", new string[]{ "EMILIA", "ЭМИЛИЯ", "ЕМІЛІЯ" }},
        {"open", new string[]{ "Open", "Открыть", "Відкрити" }},
        {"writeMessage", new string[]{ "Write a message", "Напишите сообщение", "Напишіть повідомлення" }},
        {"settings", new string[]{ "Settings", "Настройки", "Налаштування" }},
        {"guide", new string[]{ "Guide", "Руководство", "Посібник" }},
        {"tryBecomingBarista", new string[]{ "Let's try you as a barista.\nTry making me an Americano.\nYou'll need specific ingredients for an Americano,\ntry buying them.", "Давай попробуем тебя в роли бариста.\nПопробуй приготовить мне американо.\nДля американо необходимы ингредиенты,\nпопробуй их купить.", "Давай спробуємо тебе в ролі бариста.\nСпробуй приготувати мені американо.\nДля американо необхідні інгредієнти,\nспробуй їх купити." }},
        {"tryMakingCoffee", new string[]{ "Now, try making a\ncup of coffee.", "Теперь попробуй приготовить\nпорцию кофе.", "Тепер спробуй приготувати\nчашку кави." }},
        {"firstReview", new string[]{ "You received your first review!\nYou got 5 stars, and that's an excellent start!\nYou've successfully completed the training.\nEnjoy the game and have a successful\ncoffee shop development.", "Вы получили первый отзыв!\nВы получили 5 звёзд и это отличное начало!\nВы успешно прошли обучение.\nПриятной игры и успешного\nразвития кофейни.", "Ви отримали перший відгук!\nВи отримали 5 зірок і це чудовий початок!\nВи успішно пройшли навчання.\nПриємної гри та успішного\nрозвитку кав'ярні." }},
        {"orderInfo", new string[]{ "order information", "Информация о заказе", "Посібник" }},

    };

    public enum LanguageList
    {
        English,
        Russian,
        Ukraine
    }
    public void SetLanguage(int lang)
    {
        _language = (LanguageList)lang;
        localizationDelegate?.Invoke();
    }
    public int GetLanguage()
    {
        return (int)Enum.Parse(typeof(LanguageList), _language.ToString());
    }

    public Tuple<TMP_FontAsset, string> GetLocalization(string key)
    {
        switch (_language)
        {
            case LanguageList.English: return Tuple.Create(_englishFont, _stringDictionary[key][(int)_language]);
            case LanguageList.Russian: return Tuple.Create(_russianFont, _stringDictionary[key][(int)_language]);
            case LanguageList.Ukraine: return Tuple.Create(_ukraineFont, _stringDictionary[key][(int)_language]);
            default: return Tuple.Create(_englishFont, _stringDictionary[key][(int)_language]);
        }
    }

    public string GetLocalizationFromKey(string key)
    {
        return _stringDictionary[key][(int)_language];
    }
}