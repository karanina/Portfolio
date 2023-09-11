package io.github.karanina.exercises.model;

import com.google.firebase.database.Exclude;

import java.io.Serializable;

public class Ingredient implements Serializable {

private String name;
private String datePurchased;
private String volume;
private String quantity;
private String likedBy;

@Exclude // don't save this property into the database
private String key;

    public Ingredient(){
        // Needed an empty constructor to pass data back and forth between firebase database.
    }

    public Ingredient(String name, String datePurchased, String volume, String quantity, String likedBy) {
        this.name = name;
        this.datePurchased = datePurchased;
        this.volume = volume;
        this.quantity = quantity;
        this.likedBy = likedBy;

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDatePurchased() {
        return datePurchased;
    }

    public void setDatePurchased(String datePurchased) {
        this.datePurchased = datePurchased;
    }

    public String getVolume() {
        return volume;
    }

    public void setVolume(String volume) {
        this.volume = volume;
    }

    public String getQuantity() {
        return quantity;
    }

    public void setQuantity(String quantity) {
        this.quantity = quantity;
    }

    public String getLikedBy() {
        return likedBy;
    }

    public void setLikedBy(String likedBy) {
        this.likedBy = likedBy;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }
}
