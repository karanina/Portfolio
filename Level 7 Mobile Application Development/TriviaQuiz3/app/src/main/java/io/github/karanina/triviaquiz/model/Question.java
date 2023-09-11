package io.github.karanina.triviaquiz.model;

import com.google.firebase.database.Exclude;

import java.util.List;

public class Question {

    //"results":{
//        "category":"Entertainment: Video Games",
//        "type":"multiple",
//        "difficulty":"easy",
//        "question":"Who is the protagonist in the game &quot;The Walking Dead: Season One&quot;?",
//        "correct_answer":"Lee Everett",
//        "incorrect_answers":[
//        "Clementine",
//        "Kenny",
//        "Rick Grimes"
//        ]
//        }
    @Exclude
    String category;
    @Exclude
    String type;
    @Exclude
    String difficulty;
    String question;
    String correct_answer;
    List<String> incorrect_answers;

    public Question() {
    }

    public Question(String category, String type, String difficulty, String question, String correct_answer, List<String> incorrect_answers) {
        this.category = category;
        this.type = type;
        this.difficulty = difficulty;
        this.question = question;
        this.correct_answer = correct_answer;
        this.incorrect_answers = incorrect_answers;
    }

    public Question(String question, String correct_answer, List<String> incorrect_answers) {
        this.question = question;
        this.correct_answer = correct_answer;
        this.incorrect_answers = incorrect_answers;
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getDifficulty() {
        return difficulty;
    }

    public void setDifficulty(String difficulty) {
        this.difficulty = difficulty;
    }

    public String getQuestion() {
        return question;
    }

    public void setQuestion(String question) {
        this.question = question;
    }

    public String getCorrect_answer() {
        return correct_answer;
    }

    public void setCorrect_answer(String correct_answer) {
        this.correct_answer = correct_answer;
    }

    public List<String> getIncorrect_answers() {
        return incorrect_answers;
    }

    public void setIncorrect_answers(List<String> incorrect_answers) {
        this.incorrect_answers = incorrect_answers;
    }

    @Override
    public String toString() {
        return "Question{" +
                "category='" + category + '\'' +
                ", type='" + type + '\'' +
                ", difficulty='" + difficulty + '\'' +
                ", question='" + question + '\'' +
                ", correct_answer='" + correct_answer + '\'' +
                ", incorrect_answers=" + incorrect_answers +
                '}';
    }
}

