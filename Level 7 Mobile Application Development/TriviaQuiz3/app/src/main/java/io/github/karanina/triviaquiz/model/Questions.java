package io.github.karanina.triviaquiz.model;

import java.util.List;

public class Questions {
    private List<Question> results;
    public List<Question> getValue(){return this.results;}
    public String getQuizCategory(){return this.results.get(0).getCategory();}
    public String getQuizDifficulty(){return this.results.get(0).getDifficulty();}
}
