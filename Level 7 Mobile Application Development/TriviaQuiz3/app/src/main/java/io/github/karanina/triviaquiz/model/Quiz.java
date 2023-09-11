package io.github.karanina.triviaquiz.model;

import com.google.firebase.database.Exclude;

import java.util.ArrayList;

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
public class Quiz {
    String name;
    String category;
    String difficulty;
    String startDate;
    String endDate;
    @Exclude
    String key;
    @Exclude
    String score;
    ArrayList<Question> questions = new ArrayList<>();

    public Quiz() {
    }

    public Quiz(String name, String category, String difficulty, String startDate, String endDate, ArrayList<Question> questions) {
        this.name = name;
        this.category = category;
        this.difficulty = difficulty;
        this.startDate = startDate;
        this.endDate = endDate;
        this.questions = questions;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public String getDifficulty() {
        return difficulty;
    }

    public void setDifficulty(String difficulty) {
        this.difficulty = difficulty;
    }

    public String getStartDate() {
        return startDate;
    }

    public void setStartDate(String startDate) {
        this.startDate = startDate;
    }

    public String getEndDate() {
        return endDate;
    }

    public void setEndDate(String endDate) {
        this.endDate = endDate;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public ArrayList<Question> getQuestions() {
        return questions;
    }

    public void setQuestions(ArrayList<Question> questions) {
        this.questions = questions;
    }

    public void addQuestion(Question question){
        this.questions.add(question);
    }

    public String getScore() {
        return score;
    }

    public void setScore(String score) {
        this.score = score;
    }

    @Override
    public String toString() {
        return "Quiz{" +
                "name='" + name + '\'' +
                ", category='" + category + '\'' +
                ", difficulty='" + difficulty + '\'' +
                ", startDate=" + startDate +
                ", endDate=" + endDate +
                ", key='" + key + '\'' +
                ", questions=" + questions +
                '}';
    }
}
