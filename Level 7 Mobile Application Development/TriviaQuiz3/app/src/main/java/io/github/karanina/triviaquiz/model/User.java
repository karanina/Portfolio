package io.github.karanina.triviaquiz.model;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.HashMap;
import java.util.Hashtable;

public class User {

    String email;
    String username;
    String authKey;
    String accessLevel;
    String userKey;
    HashMap<String, Integer> participatedQuizzes = new HashMap<>();

    public User() {
    }

    public User(String email, String username, String authKey, String accessLevel) {
        this.email = email;
        this.username = username;
        this.authKey = authKey;
        this.accessLevel = accessLevel;
    }
    public User(String email, String username, String authKey, String accessLevel, HashMap<String, Integer> participatedQuizzes) {
        this.email = email;
        this.username = username;
        this.authKey = authKey;
        this.accessLevel = accessLevel;
        this.participatedQuizzes = participatedQuizzes;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getAuthKey() {
        return authKey;
    }

    public void setAuthKey(String authKey) {
        this.authKey = authKey;
    }

    public String getAccessLevel() {
        return accessLevel;
    }

    public void setAccessLevel(String accessLevel) {
        this.accessLevel = accessLevel;
    }

    public String getUserKey() {
        return userKey;
    }

    public void setUserKey(String userKey) {
        this.userKey = userKey;
    }

    public HashMap<String, Integer> getParticipatedQuizzes() {
        return participatedQuizzes;
    }

    public void setParticipatedQuizzes(HashMap<String, Integer> participatedQuizzes) {
        this.participatedQuizzes = participatedQuizzes;
    }
    public void addParticipatedQuiz(String quizKey, Integer quizScore) {
        this.participatedQuizzes.put(quizKey,quizScore);
    }
}
